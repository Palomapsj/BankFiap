﻿using Bank.BankFiap.Bank.Entity;

namespace Bank.BankFiap.Bank.Interface
{
    public interface IAsset : IRepository<Asset>
    {
        IList<Asset> GetAssetsByType(int type);
    }
}
