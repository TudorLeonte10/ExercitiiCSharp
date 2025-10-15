using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex7.Interfaces
{
    public interface IUserFeedbackProvider
    {
        string GetFeedback(int guess);
    }
}
