using System.Collections.Generic;

using Arsis.RentalSystem.Core.Domain;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.AccessRightsUtility
{
    internal class AccessRightsUtility
    {
        private const int ROLE_ADMIN_ID = 1;
        private const int ROLE_ACCOUNTANT_ID = 2;

        private Dictionary<int, List<UserActions>> rightsDictionary;

        public AccessRightsUtility()
        {
            CreateRightsList();
        }

        private void CreateRightsList()
        {
            rightsDictionary = new Dictionary<int, List<UserActions>>();
            
            List<UserActions> accountantUserActions = new List<UserActions>
                                                          {
                                                              UserActions.RentalPlaces_ModifyUnpayablePeriods
                                                          };

            List<UserActions> administratorUserActions = new List<UserActions>
                                                             {

                                                             };

            rightsDictionary.Add(ROLE_ADMIN_ID, administratorUserActions);
            rightsDictionary.Add(ROLE_ACCOUNTANT_ID, accountantUserActions);
        }

        public bool CheckRoleRight(Role role, UserActions action)
        {
            if(role.Id != ROLE_ADMIN_ID && role.Id != ROLE_ACCOUNTANT_ID)
            {
                return false;
            }

            return RightsDictionary[role.Id].Exists(collAction => collAction == action);
        }

        private Dictionary<int, List<UserActions>> RightsDictionary
        {
            get { return rightsDictionary; }
        }
    }
}
