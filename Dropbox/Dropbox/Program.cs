using Dropbox.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dropbox
{
    class Program
    {
        static void Main(string[] args)
        {
            var task = Task.Run((Func<Task>)Program.Run);
            task.Wait();
           // var dbx = new DropboxClient("i1P3bjveOtAAAAAAAAAAMw9a33CiHxhmXmtRDLeZxagAGCaOUvCfIzQ95mjBL4Ig");
            //var folder = ListRootFolder(dbx);

        }

        static async Task Run()
        {
            using (var dbx = new DropboxClient("i1P3bjveOtAAAAAAAAAAMw9a33CiHxhmXmtRDLeZxagAGCaOUvCfIzQ95mjBL4Ig"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
                Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
                var list = await dbx.Files.ListFolderAsync(string.Empty);
                // show folders then files
                foreach (var item in list.Entries.Where(i => i.IsFolder))
                {
                    Console.WriteLine("D  {0}/", item.Name);
                }

                foreach (var item in list.Entries.Where(i => i.IsFile))
                {
                    Console.WriteLine("F{0,8} {1}", item.AsFile.Size, item.Name);
                }
            }


        }


      
    }
}
