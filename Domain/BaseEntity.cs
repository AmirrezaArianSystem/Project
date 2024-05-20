using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public abstract class BaseEntity
{
    #region contractor
    protected BaseEntity()
    {
        
    }
    #endregion /contractor

    #region public Guid Id { get; set; }    
    public Guid Id { get; set; }
    #endregion /public Guid Id { get; set; }

    
}
