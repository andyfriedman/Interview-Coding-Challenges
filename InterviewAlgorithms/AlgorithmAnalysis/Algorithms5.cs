using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmAnalysis
{
    class Algorithms5
    {
        private Record[][] _records;

        // Record should be indexed by the combination of pk_1 and pk_2 (each are part of the "primary key")
        public class Record
        {
            public int PK_1 { get; set; }
            public int PK_2 { get; set; }
            public string Value { get; set; }
        }

        // Create an effecient cache of records as a field.
        public void LoadRecordsIntoCache(IEnumerable<Record> records)
        {
            foreach (var record in records)
            {
                _records[record.PK_1][record.PK_2] = record;
            }
            
        }

        public Record GetRecord(int pk_1, int pk_2)
        {
            // Implement GetRecord. Need to retrieve value from the cache. Retrieval should be very fast.
            return _records[pk_1][pk_2];
        }
    }
}
