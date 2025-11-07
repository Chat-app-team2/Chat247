using Chat_app_247.Config;
using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat_app_247.Services
{
    public class CreateObjectConnectDatabase
    {
        public IFirebaseClient InitializeFirebase()
        {
            IFirebaseConfig config = new FirebaseConfig
            {
                BasePath = FirebaseConfigFile.DatabaseURL // URL Realtime Database
            };

            return new FireSharp.FirebaseClient(config);
        }
    }
}
