using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {
        public interface IResource
        {
            void AccessResource();
        }

        public class RealResource : IResource
        {
            private string _resourceName;

            public RealResource(string resourceName)
            {
                _resourceName = resourceName;
            }

            public void AccessResource()
            {
                Console.WriteLine($"Accessing real resource: {_resourceName}");
            }
        }

        public class SecureResourceProxy : IResource
        {
            private RealResource _realResource;
            private string _resourceName;
            private string _accessKey;

            public SecureResourceProxy(string resourceName, string accessKey)
            {
                _resourceName = resourceName;
                _accessKey = accessKey;
            }

            public void AccessResource()
            {
                if (CheckAccess(_accessKey))
                {
                    if (_realResource == null)
                    {
                        _realResource = new RealResource(_resourceName);
                    }
                    _realResource.AccessResource();
                }
                else
                {
                    Console.WriteLine("Access denied.");
                }
            }

            private bool CheckAccess(string accessKey)
            {
                // Simulate access control logic
                return accessKey == "secret";
            }
        }



        static void Main(string[] args)
        {
            IResource secureResource = new SecureResourceProxy("top-secret-data.txt", "secret");

            // Accessing with correct access key
            secureResource.AccessResource();

            // Accessing with incorrect access key
            IResource unauthorizedResource = new SecureResourceProxy("top-secret-data.txt", "wrong_key");
            unauthorizedResource.AccessResource();
        }
    }

}
