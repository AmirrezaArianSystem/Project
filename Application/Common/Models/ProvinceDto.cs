using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ProvinceDto
    {
        #region public string Name { get; set; }
        public string Name { get; set; }
        #endregion /public string Name { get; set; }

        #region public int population { get; set; }
        [Range(minimum:100,maximum:10000000000)]
        public int population { get; set; }
        #endregion /public int population { get; set; }
    }
}
