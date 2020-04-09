using System;
using System.Collections.Generic;
using System.Text;

namespace httpPractice
{
    class Data
    {
        public string dataId { get; set; }
        public int weight { get; set; }

        public override string ToString()
        {
            return $"{dataId}: {weight}";
        }
    }
}
