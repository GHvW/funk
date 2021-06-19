using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funk {

    public static class ActionExtensions {

        public static Action<(A, B)> Tupled<A, B>(this Action<A, B> action) =>
            (data) => action(data.Item1, data.Item2);


        public static Func<A, Action<B>> Curry<A, B>(this Action<A, B> action) =>
            (a) => (b) => action(a, b);
    }
}
