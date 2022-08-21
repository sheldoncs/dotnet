using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace jwtcore.Configuration {

    public class KafkaConsumerMessageArgs<TKey, TValue> 
    {
        public TKey Key {get; set;}
        public TValue Value {get; set;}
    }
}