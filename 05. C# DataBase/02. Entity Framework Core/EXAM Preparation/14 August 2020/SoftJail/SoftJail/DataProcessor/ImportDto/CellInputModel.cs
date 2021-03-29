using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class CellInputModel
    {
        [Range(1, 1000)]
        public int CellNumber { get; set; }

        public bool HasWindow { get; set; }
    }
}

//•	Id – integer, Primary Key
//•	CellNumber – integer in the range [1, 1000] (required)
//•	HasWindow – bool(required)
//•	DepartmentId - integer, foreign key(required)
//•	Department – the cell's department (required)
//•	Prisoners - collection of type Prisoner


//        "CellNumber": 101,
//        "HasWindow": true
//      },