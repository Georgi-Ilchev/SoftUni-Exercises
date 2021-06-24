using Panda.Data;
using Panda.Data.Models;
using Panda.ViewModels.Receipts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Panda.Services
{
    public class ReceiptsService : IReceiptsService
    {
        private readonly PandaDbContext data;

        public ReceiptsService(PandaDbContext data)
        {
            this.data = data;
        }

        public void Create(string packageId, string recipientId)
        {
            var package = this.data
                .Packages
                .Find(packageId);

            var receipt = new Receipt()
            {
                Fee = package.Weight * 2.67m,
                IssuedOn = DateTime.Now,
                RecipientId = recipientId,
                PackageId = packageId
            };

            this.data.Receipts.Add(receipt);
            this.data.SaveChanges();
        }

        public IEnumerable<GetReceiptsViewModel> GetAll(string userId)
        {
            var receipts = this.data
                .Receipts
                .Where(r => r.RecipientId == userId)
                .Select(r => new GetReceiptsViewModel()
                {
                    Fee = r.Fee,
                    Id = r.Id,
                    IssuedOn = r.IssuedOn,
                    RecipientName = r.Recipient.Username
                })
                .ToList();

            return receipts;
        }
    }
}
