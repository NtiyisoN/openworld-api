using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web;
using System.Windows.Forms;
using System.Diagnostics;
using Facebook;
using norwold.model;
using DataModel.libHosting;
using DataModel.libDB;
using NHibernate;


namespace norwold.forms
{
    public partial class FrmLogon : Form
    {
        FacebookClient fb, fbuser;
        Dictionary<string, object> response;
        private hostUser cUser;
        private nwdbConnection nw;
        private nwdbRepository repo;
        private bool isAdmin;

        private sysFacebook fbRecord;
        private hostUser CurrentUser;
        private bool userAuthenticated;

        public hostUser Logon { get { return cUser; } set { cUser = Logon; isAdmin = (cUser.UserType.LongName == "Administrator"); } }
        public nwdbConnection Database { get { return nw; } set { nw = Database; } }
        public nwdbRepository Repository { get { return repo; } set { repo = Repository; } }

        protected ISessionFactory sessionFactory;
        protected ISession sess;
        protected sysTreeManager stm;

        public FrmLogon()
        {
            InitializeComponent();
            fb = new FacebookClient();
            response = new Dictionary<string,object>();
            //Default to not Logged in
            userAuthenticated = false;
        }

        public void initFB()
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           
            
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            FacebookOAuthResult authResult;
            
            string OWUsername = "Error";
            bool userUnique;

            if (fb.TryParseOAuthCallbackUrl(e.Url, out authResult))
            {

                if (authResult.IsSuccess)
                {




                    //System.Windows.Forms.MessageBox.Show("Logged In");
                    SetMessage("Access Token" + authResult.AccessToken);
                    //fb.AccessToken = authResult.AccessToken;

                    var accesstoken = authResult.AccessToken;
                    fbuser = new FacebookClient(accesstoken);
                    fb.AccessToken = accesstoken;

                    var results = (IDictionary<string, object>)fb.Get("/me");
                    fbRecord = sysFacebook.ParseResponse(results, authResult);

                    if (fbRecord == null)
                    {
                        System.Windows.Forms.MessageBox.Show("Failed to Parse Response");
                    }
                    else
                    {
                        SetMessage("LOGON via FB Sucess");
                        SetMessage(fbRecord.LongDesc());
                    }

                    CurrentUser = sysFacebook.UserExists(sess, fbRecord);
                    if (CurrentUser != null)
                    {
                        SetMessage("User Found:" + CurrentUser.LongName);
                        if (CurrentUser.fbAccessToken != fbRecord.AccessToken)
                        {
                            SetMessage("Refreshing token");
                            CurrentUser.fbAccessToken = fbRecord.AccessToken;
                            CurrentUser.fbTokenExpires = fbRecord.Expires;
                            sess.SaveOrUpdate(CurrentUser);
                            sess.Flush();
                        }
                        //System.Windows.Forms.MessageBox.Show("Welcome Back : "+CurrentUser.LongName, "User Login");
                        //Ok to proceed
                        SetOkToProceed();

                    }
                    else
                    {
                        //Register new
                        if (System.Windows.Forms.MessageBox.Show("User not registered, Register now?", "User Registration", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                        {
                            //Register
                            userUnique = false;
                            while (userUnique == false)
                            {
                                OWUsername = Microsoft.VisualBasic.Interaction.InputBox("Register Username", "Enter  A unique username for OpenWorld to be Associated with this FaceBook Account", "Name", 200, 400);
                                CurrentUser = sysFacebook.FindByUserName(sess, OWUsername);
                                userUnique = (CurrentUser == null);
                                if (!userUnique) { SetMessage("Username " + OWUsername + " is taken, please choose another"); }

                            }
                            //Create new
                            SetMessage("Creating new user:" + OWUsername);
                            CurrentUser = new hostUser(OWUsername.Substring(0, Math.Min(OWUsername.Length, nwdbConst.LEN_SHORT)), OWUsername, fbRecord);
                            CurrentUser.LogEvent(null, null, "Registered", "User Registered with OpenWorld", "Congratulations, you have sucessfully registered for openworld");
                            repo.Save(CurrentUser);
                            SetOkToProceed();
                        }

                    }

                }
                else  //Auth Failed 
                { SetMessage("FBAuth failed;" + authResult.ErrorDescription); }
            }

            
        }
        

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        protected virtual void SetMessage(String msg)
        {
            Debug.Print(msg);
            tboxMsg.Text = msg;
        }

        private void FrmLogon_Load(object sender, EventArgs e)
        {
            Debug.Print("LOAD FIRED");
            //Create&Drop
            if (nw == null) { nw = new nwdbConnection(); }
            sessionFactory = nw.Factory;
            if (repo == null) { repo = new nwdbRepository(sessionFactory.OpenSession()); }
            sess = repo.GetSession();
            //this.btnLogin_Click(this, null);

            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            webBrowser1.BringToFront();
            //If Sucessfully Logged in already and pressing Login again, show menu
            if (userAuthenticated) {
                CurrentUser.LogEvent(null, null, "Login", "User Logged into OpenWorld", "Congratulations, you have sucessfully logged in to for openworld on "+DateTime.Now.ToString());
                Repository.Save(CurrentUser);
                DialogResult = DialogResult.OK; 
            } 

            string[] extendedPermissions = new[] { "publish_stream", "offline_access" };
            var parameters = new Dictionary<string, object>

                                {

                                    { "display", "popup" },
                                    { "response_type", "token" }, 
                                    { "redirect_uri",hostConstants.redirectURI},
                                    {  "scope" , "email,public_profile,publish_actions"}
                                };

            /**
            result = fb.Get("oauth/access_token", new
            {
                client_id = appId,
                client_secret = appSecret,
                grant_type = "client_credentials"
            });
            **/

            Debug.Print("Fuck this");
            Debug.Print("fb:" + fb.ToString());
            //SetMessage("result:" + result.ToString());

            //SetMessage("AccessToken:" + fb.AccessToken.ToString());
            fb.AppId = hostConstants.appId;
            fb.AppSecret = hostConstants.appSecret;


            var loginURL = fb.GetLoginUrl(parameters);
           Debug.Print("loginURL:" + loginURL);
            webBrowser1.Navigate(loginURL);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Post to facebook

            var args = new Dictionary<string, object>();
            args["message"] = fbRecord.FirstName+" has joined Openworld.";
            args["caption"] = "Sod Winter, OpenWorld is coming";
            args["description"] = "Sabbath is my bunny (desc)";
            args["name"] = CurrentUser.LongName;
            args["picture"] = hostConstants.iconURI;
            args["link"] = hostConstants.redirectURI;
            try
            {
                fb.Post("/me/feed", args);
            } catch(Exception ex) {
                SetMessage("Post to FaceBok failed: Msg" + ex.ToString());
            }
        }

        private void SetOkToProceed()
        {
            tboxRegister.Text = CurrentUser.LongName;
            btnPost.Enabled = true;
            btnLogin.Text = "&Login";
            userAuthenticated = true;
            SetMessage("Welcome to OpenWorld:" + CurrentUser.LongName + ", click Login to proceed");
        
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

    }


}
