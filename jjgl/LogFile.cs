using System;
using System.IO;

namespace 基金管理
{
    public partial class LOG
    {
        private static volatile LOG instance;

        private static FileInfo myFile;

        private static object syncRoot = new Object();

        public static LOG Instance
        {
            get 
            {
                if (instance == null) 
                {
                    lock (syncRoot) 
                    {
                    if (instance == null) 
                        instance = new LOG();
                    }
                }

                return instance;
            }
        }        

        public  void Run() {

        }

        public LOG()
        {
            
        }    

        public void Info(string message) {
            StreamWriter sw = new StreamWriter(@"log.txt",true);
            sw.WriteLine(message);
            sw.Close();
        }  
    }
}