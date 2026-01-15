using System;
using System.Collections.Generic;

using Arsis.RentalSystem.Core.Bll;
using Arsis.RentalSystem.Core.Domain;

using GridViewExtensions;

namespace Arsis.RentalSystem.AdministrationConsole.BLL.Interface
{
    public interface IContractService
    {
        int InsertContractRecord(Contract filledContract, int serviceId);

        int InsertContractRecord(string contractNumber,
                                         DateTime durationFrom,
                                         DateTime durationTo,
                                         int serviceId,
                                         DateTime cashlessPaymentControlDate,
                                         string contractorCode, bool isExporting);

        int InsertContractRecord(string contractNumber,
                                         DateTime durationFrom,
                                         DateTime durationTo,
                                         int serviceId,
                                         string contractorCode, bool isExporting);

        void UpdateContractRecord(int id,
                                         DateTime durationFrom,
                                         DateTime durationTo,
                                         DateTime cashlessPaymentControlDate, bool isExporting);

        void UpdateContractRecord(int id,
                                         DateTime durationFrom,
                                         DateTime durationTo, bool isExporting);

        BindingListView<Contract> GetContracts(ContractState state, DateTime fromDate, DateTime toDate);
        Contract GetContract(int id);
        void Transfer(int contractIdFrom, int contractIdTo, List<int> rentalPlacesIds, DateTime date);
        void AddRentalPlaceToContract(int contractId, int rentalPlaceId, DateTime date);
        void RemoveRentalPlaceFromContract(int contractId, int rentalPlaceId, DateTime date);
        List<RentalPlace> GetRentalPlaces(int id);
        List<RentalPlace> GetRentalPlaces();
        bool CheckContractExistance(string number);
        Contract GetContractByNumber(string number);
        void CalculateContract(int contractId,
                           DateTime date,
                           out decimal renderedAmmount,
                           out decimal recievedAmmount,
                           out decimal balance);
        void CloseContract(int contractId, DateTime date);
        BindingListView<Contractor> GetContractors(string parentCode);
        Contractor GetContractor(string contractorCode);
        List<string> GetContractorsFilter();
        List<string> GetContractsFilter();
        List<string> GetHistory(int contractId);
        DateTime GetContractRentalPlaceFromDate(int contractId, int placeId);
        bool CheckAddingPlaceDateIntersection(int contractId, int placeId, DateTime dateFrom, DateTime dateTo);
        DateTime GetCashlessPaymentControlDate(int contractId);
        void GetMinimalContractDuration(int contractId, out DateTime dateFrom, out DateTime dateTo);
        /// <summary>
        /// Get last rental cashless payment for contract
        /// </summary>
        /// <param name="contractId"></param>
        /// <returns>DateFrom, DateTo pair</returns>
        DateTime[] GetLastRentalCashlessPaymentForContract(int contractId);
    }
}