/**
 * 
 * Author       :: Basilius Bias Astho Christyono
 * Mail         :: bias@indomaret.co.id
 * Phone        :: (+62) 889 236 6466
 * 
 * Department   :: IT SD 03
 * Mail         :: bias@indomaret.co.id
 * 
 * Catatan      :: Pengaturan Aplikasi
 *              :: Harap Didaftarkan Ke DI Container
 * 
 */

using System;
using System.Collections.Generic;

using Microsoft.Extensions.Options;

using bifeldy_sd3_lib_31.Models;
using bifeldy_sd3_lib_31.Utilities;

namespace bifeldy_sd3_wapi_31.Utilities {

    public interface IApp : IApplication {
        string Author { get; }
        List<string> ListDcCanUse { get; }
    }

    public sealed class CApp : CApplication, IApp {

        private readonly Env _env;

        public string Author { get; }

        public List<string> ListDcCanUse { get; }

        public CApp(IOptions<Env> env) {
            _env = env.Value;

            Author = "B. Bias A. Ch. :: bias@indomaret.co.id";
            ListDcCanUse = new List<string> { "INDUK", "DEPO", "SEWA" };
        }

    }

}
