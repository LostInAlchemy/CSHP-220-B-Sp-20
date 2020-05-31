using System;

namespace DeviceApp.Models
{
    public class TypeModel
    {
        public byte TypeInventoryId { get; set; }
        public string TypeType { get; set; }
        public string TypeDesc { get; set; }
        public DateTime TypeAddedDate { get; set; }

        public Repository.TypeModel ToRepositoryModel()
        {
            var typeRepository = new Repository.TypeModel
            {
                TypeInventoryId = TypeInventoryId,
                TypeType        = TypeType,
                TypeDesc        = TypeDesc,
                TypeAddedDate   = TypeAddedDate,
            };

            return typeRepository;
        }

        public static TypeModel ToModel(Repository.TypeModel typeRespository)
        {
            var typeModel = new TypeModel
            {
                TypeInventoryId = typeRespository.TypeInventoryId,
                TypeType        = typeRespository.TypeType,
                TypeDesc        = typeRespository.TypeDesc,
                TypeAddedDate   = typeRespository.TypeAddedDate
            };

            return typeModel;
        }

        public TypeModel Clone()
        {
            return (TypeModel)MemberwiseClone();
        }
    }
}
