using People_Data.Models;

namespace People_Data.HTTP
{
    public class DBHelper
    {
        private EF_DataContext _context;
        public DBHelper(EF_DataContext context)
        {
            _context = context;
        }

        public List<PeopleModel> GetPeople()
        {
            List<PeopleModel> response = new List<PeopleModel>();
            var dataList = _context.peoples.ToList();
            dataList.ForEach(row => response.Add(new PeopleModel()
            {
                Id = row.Id,
                FirstName = row.FirstName,
                LastName = row.LastName,
                Age = row.Age,

            }));
            return response;
        }
        public PeopleModel GetbyID(Guid ID)
        {
            PeopleModel response = new PeopleModel();
            var row = _context.peoples.Where(d => d.Id.Equals(ID)).FirstOrDefault();

           
                return new PeopleModel()
                {
                    Id = row.Id,
                    FirstName = row.FirstName,
                    LastName = row.LastName,
                    Age = row.Age
                };
            
           
        }
        public void CreateOrder(PeopleModel nModel)
        {
            
            if(nModel.Age>=18 && nModel.Age <=60)
            {
                var dbTable = new People();
                dbTable.Id = Guid.NewGuid();
                dbTable.FirstName = nModel.FirstName;
                dbTable.LastName = nModel.LastName;
                dbTable.Age = nModel.Age;
                _context.peoples.Add(dbTable);
                _context.SaveChanges();

            }
            else
            {
                return;
            }
           
        }
        public void SaveOrder(PeopleModel nModel)
        {
            var dbTable = new People();
           

            dbTable =_context.peoples.Find(nModel.Id);
           
            if (dbTable != null && Enumerable.Range(18,60).Contains(nModel.Age))
            {
                dbTable.FirstName = nModel.FirstName;
                dbTable.LastName = nModel.LastName;
                dbTable.Age = nModel.Age;
                _context.SaveChanges();



            }
            else
            {
                return;
            }
            
            
            
                //if (nModel.FirstName!=null)
            //{
            //    //PUT
            // //   dbTable = _context.peoples.Where(d => d.Id.Equals(nModel.Id)).FirstOrDefault();
            //    dbTable = _context.peoples.Find(nModel.Id);
            //    if (dbTable != null)
            //    {
            //        dbTable.FirstName = nModel.FirstName;
            //        dbTable.LastName = nModel.LastName;
            //        dbTable.Age = nModel.Age;
            //    }
            //}
            //else
            //{
            //    //POST
            //    dbTable.Id = Guid.NewGuid();
            //    dbTable.FirstName=nModel.FirstName;
            //    dbTable.LastName=nModel.LastName;
            //    dbTable.Age=nModel.Age;
            //    _context.peoples.Add(dbTable);
            //}
            
        }

        public void DeleteOrder(Guid id)
        {
            var order = _context.peoples.Where(d => d.Id.Equals(id)).FirstOrDefault();
            if (order != null)
            {
                _context.peoples.Remove(order);
                _context.SaveChanges();
            }
            
        }
        //public void crbyId(PeopleModel nmodel)
        //{
        //    var flag = new People();
        //    flag=_context.peoples.Where(d => d.Id.Equals(nmodel.Id)).FirstOrDefault();
        //    if(flag != null)
        //    {
        //        flag.FirstName = nmodel.FirstName;
        //        flag.LastName = nmodel.LastName;    
        //        flag.Age = nmodel.Age;
        //        _context.SaveChanges();

        //    }

        //}


    }
    
}
