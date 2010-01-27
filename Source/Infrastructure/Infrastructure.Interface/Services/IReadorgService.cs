using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace ACOT.Infrastructure.Interface.Services
{
    /// <summary>
    /// ���� ��������� ���������� �������� ��� ��������
    /// ������� ������������ ��������� ���������� �� �����������.
    /// </summary>
    public interface IReadorgService
    {
        ACOT.Infrastructure.Interface.BusinessEntities.Organization GetOrg(string dir);
        
        List<ACOT.Infrastructure.Interface.BusinessEntities.Organization> orgsList(string dir);
    }
}
