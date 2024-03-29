﻿using System;
using DatabaseController;

namespace BookEditor
{
    public class OrderTable : DatabaseTable
    {
        public const string KEY_ID = "id";
        public const string KEY_CLIENT_ID = "client_id";
        public const string KEY_BOOK_ID = "book_id";
        public const string KEY_QUANTITY = "quantity";
        public const string KEY_STATE = "state";
        public const string KEY_DATE = "date";
        public const string KEY_STATE_DATE = "state_date";
        public const string KEY_PRICE = "total_price";
        public const string KEY_ADDRESS = "address";

        public const int WAITING = 0;
        public const int DISPATCHED = 1;
        public const int TO_DISPATCH = 2;

        private static OrderTable instance = new OrderTable();

        public static OrderTable Instance { get { return instance; } }

        private OrderTable() { }

        override protected string getTableName() { return "orders"; }

        override protected string getCreationScript()
        {
            return String.Format("create table {0} ({1} INTEGER PRIMARY KEY AUTOINCREMENT, {2} INTEGER NOT NULL, {3} INTEGER NOT NULL, {4} INTEGER NOT NULL DEFAULT 0, {5} INTEGER NOT NULL DEFAULT 0, {6} TEXT, {7} TEXT, {8} REAL NOT NULL DEFAULT 0, {9} TEXT NOT NULL, FOREIGN KEY({2}) REFERENCES users(id), FOREIGN KEY({3}) REFERENCES books(id));", getTableName(), KEY_ID, KEY_CLIENT_ID, KEY_BOOK_ID, KEY_QUANTITY, KEY_STATE, KEY_DATE, KEY_STATE_DATE, KEY_PRICE, KEY_ADDRESS);
        }
    }
}
