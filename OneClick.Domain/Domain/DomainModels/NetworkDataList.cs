using Newtonsoft.Json;

namespace OneClick.Domain.Domain.DomainModels
{
    public static class NetworkDataList
    {
        public static string List = "[\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 15,\r\n    \"Name\": \"BNB Smart Chain (BEP20)\",\r\n    \"Network\": \"BSC\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.33,\r\n    \"WithdrawMin\": 0.35,\r\n    \"WithdrawIntegerMultiple\": 0.00000001,\r\n    \"WithdrawMax\": 10000000000.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^[1-5a-z\\\\.]{1,12}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"^[0-9A-Za-z\\\\-_,]{1,120}$\",\r\n    \"minConfirm\": 1,\r\n    \"Name\": \"EOS\",\r\n    \"Network\": \"EOS\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"Both a memo/tag and an address are required to successfully deposit your assets to Binance.\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 1.0,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.0001,\r\n    \"WithdrawMax\": 10000000000.0,\r\n    \"SameAddress\": true\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(?!0x)(?!bc1)(?!bnb1)[a-z0-9_-]{1}[a-z0-9_.-]{0,62}[a-z0-9_-]{1}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 1,\r\n    \"Name\": \"NEAR Protocol\",\r\n    \"Network\": \"NEAR\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"Please make sure that the token contract address is usdt.tether-token.near, depositing a token with different contract address may result in loss of funds. Thank you for your understanding\",\r\n    \"UnlockConfirm\": 5,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.8,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 10000000000.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 12,\r\n    \"Name\": \"AVAX C-Chain\",\r\n    \"Network\": \"AVAXC\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"Please note that this deposit address supports C-Chain deposits. For X-Chain deposits, please use the AVAX network.\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.19,\r\n    \"WithdrawMin\": 0.38,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 9999999.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 120,\r\n    \"Name\": \"Arbitrum One\",\r\n    \"Network\": \"ARBITRUM\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 120,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.53,\r\n    \"WithdrawMin\": 1.06,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 9999999.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(1)[0-9a-z-A-Z]{44,50}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 3,\r\n    \"Name\": \"Asset Hub (Polkadot)\",\r\n    \"Network\": \"STATEMINT\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 1.0,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 9999999.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(bnb1)[0-9a-z]{38}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"^[0-9A-Za-z\\\\-_]{1,120}$\",\r\n    \"minConfirm\": 1,\r\n    \"Name\": \"BNB Beacon Chain (BEP2)\",\r\n    \"Network\": \"BNB\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"Both a memo/tag and an address are required to successfully deposit your assets to Binance.\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"The wallet is currently undergoing maintenance. Withdrawals for this asset will be resumed shortly.\",\r\n    \"withdrawEnable\": false,\r\n    \"WithdrawFee\": 0.0,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 10000000000.0,\r\n    \"SameAddress\": true\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": true,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 6,\r\n    \"Name\": \"Ethereum (ERC20)\",\r\n    \"Network\": \"ETH\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 64,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 6.0,\r\n    \"WithdrawMin\": 19.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 10000000000.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 1,\r\n    \"Name\": \"KAVAEVM\",\r\n    \"Network\": \"KAVAEVM\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 1.0,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 9999999.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 25,\r\n    \"Name\": \"Optimism\",\r\n    \"Network\": \"OPTIMISM\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"Please note that L2 networks require its corresponding L1 transaction to reach finality (64 blocks) before deposits can be unlocked. ETA ~25 min\",\r\n    \"UnlockConfirm\": 100,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.28,\r\n    \"WithdrawMin\": 0.56,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 9999999.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 200,\r\n    \"Name\": \"Polygon\",\r\n    \"Network\": \"MATIC\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 300,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.5,\r\n    \"WithdrawMin\": 5.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 1000000000.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^[1-9A-HJ-NP-Za-km-z]{32,44}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 1,\r\n    \"Name\": \"Solana\",\r\n    \"Network\": \"SOL\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 4.4,\r\n    \"WithdrawMin\": 25.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 9999999.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(tz[1,2,3])[a-zA-Z0-9]{33}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 4,\r\n    \"Name\": \"Tezos\",\r\n    \"Network\": \"XTZ\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.3,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 10000000000.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^T[1-9A-HJ-NP-Za-km-z]{33}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 1,\r\n    \"Name\": \"Tron (TRC20)\",\r\n    \"Network\": \"TRX\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 0,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 1.2,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.000001,\r\n    \"WithdrawMax\": 10000000000.0,\r\n    \"SameAddress\": false\r\n  },\r\n  {\r\n    \"AddressRegex\": \"^(0x)[0-9A-Fa-f]{40}$\",\r\n    \"coin\": \"USDT\",\r\n    \"depositDesc\": \"\",\r\n    \"depositEnable\": true,\r\n    \"IsDefault\": false,\r\n    \"MemoRegex\": \"\",\r\n    \"minConfirm\": 1,\r\n    \"Name\": \"opBNB\",\r\n    \"Network\": \"OPBNB\",\r\n    \"ResetAddressStatus\": false,\r\n    \"SpecialTips\": \"\",\r\n    \"UnlockConfirm\": 100,\r\n    \"withdrawDesc\": \"\",\r\n    \"withdrawEnable\": true,\r\n    \"WithdrawFee\": 0.2,\r\n    \"WithdrawMin\": 10.0,\r\n    \"WithdrawIntegerMultiple\": 0.00000001,\r\n    \"WithdrawMax\": 9999999.0,\r\n    \"SameAddress\": false\r\n  }\r\n]";
    }



    public class BinanceNetwork
    {
        //
        // Сводка:
        //     Regex for an address on the network
        public string AddressRegex { get; set; }


        //
        // Сводка:
        //     Asset name
        [JsonProperty("coin")]
        public string Asset { get; set; }


        //
        // Сводка:
        //     Deposit description
        [JsonProperty("depositDesc")]
        public string DepositDescription { get; set; }


        //
        // Сводка:
        //     Deposit enabled
        [JsonProperty("depositEnable")]
        public bool DepositEnabled { get; set; }

        //
        // Сводка:
        //     Is default network
        public bool IsDefault { get; set; }

        //
        // Сводка:
        //     Regex for a memo
        public string MemoRegex { get; set; }


        //
        // Сводка:
        //     Minimal confirmations for balance confirmation
        [JsonProperty("minConfirm")]
        public int MinConfirmations { get; set; }

        //
        // Сводка:
        //     Name
        public string Name { get; set; }


        //
        // Сводка:
        //     Network
        public string Network { get; set; }


        //
        // Сводка:
        //     Reset address status
        public bool ResetAddressStatus { get; set; }

        //
        // Сводка:
        //     Tips
        public string SpecialTips { get; set; }


        //
        // Сводка:
        //     Confirmation number for balance unlock
        public int UnlockConfirm { get; set; }

        //
        // Сводка:
        //     Withdraw description
        [JsonProperty("withdrawDesc")]
        public string WithdrawDescription { get; set; }


        //
        // Сводка:
        //     Withdraw is enabled
        [JsonProperty("withdrawEnable")]
        public bool WithdrawEnabled { get; set; }

        //
        // Сводка:
        //     Fee for withdrawing
        public decimal WithdrawFee { get; set; }

        //
        // Сводка:
        //     Minimal withdraw quantity
        public decimal WithdrawMin { get; set; }

        //
        // Сводка:
        //     Min withdraw step
        public decimal WithdrawIntegerMultiple { get; set; }

        //
        // Сводка:
        //     Max withdraw quantity
        public decimal WithdrawMax { get; set; }

        //
        // Сводка:
        //     If the asset needs to provide memo to withdraw
        public bool SameAddress { get; set; }
    }
}
