using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace L06mabob.Models
{
public class AzureManager
	{

		private static AzureManager instance;
        private MobileServiceClient client;
		private IMobileServiceTable<gingerbeer> pumpwater;

		private AzureManager()
		{
            this.client = new MobileServiceClient("http://yogurtdrink.azurewebsites.net");
            this.pumpwater = this.client.GetTable<gingerbeer>();
		}

		public MobileServiceClient AzureClient
		{
			get { return client; }
		}

        public async Task<List<gingerbeer>> getTable()
		{
			return await this.pumpwater.ToListAsync();
		}

		public static AzureManager AzureManagerInstance
		{
			get
			{
				if (instance == null)
				{
					instance = new AzureManager();
				}

				return instance;
			}
		}
	}
}
