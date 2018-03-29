using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CoreUtils
{
    public class Util
    {
        public static async void deleteTempClips()
        {
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            try
            {
                storageFolder = await storageFolder.GetFolderAsync("TempClip");
            }
            catch (IOException ex)
            {
                return;
            }

            IReadOnlyList<IStorageItem> itemsList = await storageFolder.GetItemsAsync();
            foreach (var item in itemsList)
            {
                if (item is StorageFile)
                {
                    await item.DeleteAsync();
                }
            }
        }
    }
}
