using DeviceDB;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class TypeModel
    {
        public byte TypeInventoryId { get; set; }
        public string TypeType { get; set; }
        public string TypeDesc { get; set; }
        public System.DateTime TypeAddedDate { get; set; }
    }

    public class TypeRepository
    {
        public TypeModel Add(TypeModel typeModel)
        {
            var typeDb = ToDbModel(typeModel);

            DatabaseManager.Instance.TypeInventory.Add(typeDb);
            DatabaseManager.Instance.SaveChanges();

            typeModel = new TypeModel
            {
                TypeInventoryId = typeDb.TypeInventoryId,
                TypeType        = typeDb.TypeType,
                TypeDesc        = typeDb.TypeDesc,
                TypeAddedDate   = typeDb.TypeAddedDate
            };
            return typeModel;
        }

        public List<TypeModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.TypeInventory
              .Select(t => new TypeModel
              {
                  TypeInventoryId   = t.TypeInventoryId,
                  TypeType          = t.TypeType,
                  TypeDesc          = t.TypeDesc,
                  TypeAddedDate     = t.TypeAddedDate,
              }).ToList();

            return items;
        }

        public bool Update(TypeModel typeModel)
        {
            var original = DatabaseManager.Instance.TypeInventory.Find(typeModel.TypeInventoryId);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(typeModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int typeInventoryId)
        {
            var items = DatabaseManager.Instance.TypeInventory
                                .Where(t => t.TypeInventoryId == typeInventoryId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.TypeInventory.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private TypeInventory ToDbModel(TypeModel typeModel)
        {
            var typeDb = new TypeInventory
            {
                TypeInventoryId = typeModel.TypeInventoryId,
                TypeType        = typeModel.TypeType,
                TypeDesc        = typeModel.TypeDesc,
                TypeAddedDate   = typeModel.TypeAddedDate,
            };

            return typeDb;
        }
    }
}
