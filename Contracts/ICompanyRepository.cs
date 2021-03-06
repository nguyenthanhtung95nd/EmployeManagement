﻿using System;
using System.Collections.Generic;
using Entities.Models;

namespace Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges = false);
        Company GetCompany(Guid companyId, bool trackChanges = false);
    }
}