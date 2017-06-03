using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Net;
using System.Net.Sockets;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Operators;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace FPBMTTC_FinalC_M_vs2017.Controller
{
    class CAController
    {
        public const string service = "https://localhost/Restful/FinalC-M/Values/";
        enum Method
        {
            GetCert,
            GenerateCA,
            GetLastedCert,
            RegisterUser
        }
    }
}
