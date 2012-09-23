using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrunYorum.Data.Entities;
using UrunYorum.Data.Contractor.Base;
using UrunYorum.Data.Contractor.IServices;
using UrunYorum.Data.Engine.Infrastructure;
using UrunYorum.Data.Engine.IRepositories;

namespace UrunYorum.Data.Contractor
{
    public class ManufacturerDataService : EntityService<IManufacturerRepository, Manufacturer>, IManufacturerDataService
    {
        public ManufacturerDataService(IManufacturerRepository repository, IUnitOfWork unitOfWork)
            : base(repository, unitOfWork)
        {

        }
    }
}
