using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SharedKanclPlaylistWCFSvc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class SharedKanclPlaylistWCFSvc : ISharedKanclPlaylistWCFSvc
    {
        static List<string> urls = new List<string>();

        public string GetYoutubeUrl()
        {
            string newUrl = "";
            if (urls.Count > 0)
            {
                newUrl = urls.First();
                urls.Remove(newUrl);
            }
            return newUrl;
        }

        //public string GetData(int value)
        //{
        //    return string.Format("You entered: {0}", value);
        //}

        //public CompositeType GetDataUsingDataContract(CompositeType composite)
        //{
        //    if (composite == null)
        //    {
        //        throw new ArgumentNullException("composite");
        //    }
        //    if (composite.BoolValue)
        //    {
        //        composite.StringValue += "Suffix";
        //    }
        //    return composite;
        //}

        public string SendYoutubeUrl(string url)
        {
            urls.Add(url);
            return "OK";
        }
    }
}
