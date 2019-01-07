using RedStarter.Business.DataContract.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RedStarter.Business.DataContract.Application.Interfaces
{
    public interface IUserApplicationManager
    {
        Task<bool> CreateApplication(ApplicationCreateDTO applicationDTO);
    }
}
