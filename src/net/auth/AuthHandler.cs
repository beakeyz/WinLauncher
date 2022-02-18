using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinLauncher.src.net.auth
{
    public class AuthHandler
    {
        public bool isAuth;
        public App parent;

        public AuthHandler(App parent)
        {
            this.isAuth = false;
            this.parent = parent;
        }

        public void UpdateAuthState()
        {

        }

        public string GetAuthStateFromServer()
        {
            this.parent.reqCrafter.MakeGetRequest("/auth_check", callback =>
            {
                if (callback.IsSuccessful)
                {
                    foreach (var header in callback.Headers)
                    {
                        if (header.Name == "client-token")
                        {
                            //This is questionable
                            Settings.BAKSERV_TOKEN = header.ToString();
                            this.isAuth = true;
                            return 20;
                        }
                    }

                }
                this.isAuth = false;
                return -1;
            }
            );
            return "";
        }

        public bool getAuthState()
        {
            return this.isAuth;
        }
    }
}
