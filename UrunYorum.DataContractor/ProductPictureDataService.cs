using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Contractor.Base;
using UrunYorum.Data.Engine.IRepositories;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Engine.Infrastructure;

namespace UrunYorum.Data.Contractor
{
    public class ProductPictureDataService : EntityService<IProductPictureRepository, ProductPicture>, IProductPictureDataService
    {
        public ProductPictureDataService(IProductPictureRepository repository, IUnitOfWork unitOfWork)
            :base(repository, unitOfWork)
        {

        }
    }
}
