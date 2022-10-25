using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funk {

    public static class Act {

        // Composition

        public static Action<A> Compose<A, B>(
            this Action<B> f, 
            Func<A, B> g
        ) =>
            (x) => f(g(x));


        // Transformation

        public static Action<(A, B)> Tupled<A, B>(
            this Action<A, B> action
        ) =>
            (data) => action(data.Item1, data.Item2);


        public static Func<A, Action<B>> Curry<A, B>(
            this Action<A, B> action
        ) =>
            (a) => (b) => action(a, b);


        // Application

        public static Action<(A, B)> Apply<A, B>(
            this Action<A, B> action, 
            (A, B) args
        ) =>
            (data) => action(data.Item1, args.Item2);


        public static Action<(A, B, C)> Apply<A, B, C>(
            this Action<A, B, C> action, 
            (A, B, C) args
        ) =>
            (data) => action(data.Item1, args.Item2, args.Item3);


        public static Action<(A, B, C, D)> Apply<A, B, C, D>(
            this Action<A, B, C, D> action, 
            (A, B, C, D) args
        ) =>
            (data) => action(data.Item1, args.Item2, args.Item3, args.Item4);
    }
}
