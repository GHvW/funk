using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funk {

    public static class Fn {

        // Composition

        public static Func<A, C> AndThen<A, B, C>(
            this Func<A, B> f, 
            Func<B, C> g
        ) =>
            (x) => g(f(x));


        public static Action<A> AndThen<A, B, C>(
            this Func<A, B> f, 
            Action<B> g
        ) =>
            (x) => g(f(x));


        public static Func<A, C> Compose<A, B, C>(
            this Func<B, C> f, 
            Func<A, B> g
        ) =>
            (x) => f(g(x));


        // Transformation

        public static Func<(A, B), C> Tupled<A, B, C>(
            this Func<A, B, C> fn
        ) =>
            (data) => fn(data.Item1, data.Item2);


        public static Func<(A, B, C), D> Tupled<A, B, C, D>(
            this Func<A, B, C, D> fn
        ) =>
            (data) => fn(data.Item1, data.Item2, data.Item3);


        public static Func<(A, B, C, D), E> Tupled<A, B, C, D, E>(
            this Func<A, B, C, D, E> fn
        ) =>
            (data) => fn(data.Item1, data.Item2, data.Item3, data.Item4);


        public static Func<A, Func<B, C>> Curry<A, B, C>(
            this Func<A, B, C> fn
        ) =>
            (a) => (b) => fn(a, b);


        public static Func<A, Func<B, Func<C, D>>> Curry<A, B, C, D>(
            this Func<A, B, C, D> fn
        ) =>
            (a) => (b) => (c) => fn(a, b, c);

        public static Func<A, Func<B, Func<C, Func<D, E>>>> Curry<A, B, C, D, E>(
            this Func<A, B, C, D, E> fn
        ) =>
            (a) => (b) => (c) => (d) => fn(a, b, c, d);


        // Application
        public static C Apply<A, B, C>(
            this Func<A, B, C> fn, 
            (A, B) args
        ) =>
            fn(args.Item1, args.Item2);


        public static D Apply<A, B, C, D>(
            this Func<A, B, C, D> fn, 
            (A, B, C) args
        ) =>
            fn(args.Item1, args.Item2, args.Item3);


        public static E Apply<A, B, C, D, E>(
            this Func<A, B, C, D, E> fn, 
            (A, B, C, D) args
        ) =>
            fn(args.Item1, args.Item2, args.Item3, args.Item4);


        // Partial Application

        // The idea here is that you often want to apply the data structure (the first argument to an extension method) last
        // You know all the other arguments to the method will remain static, and only the data structure will change
        // So we "apply" all the other arguments, leaving a function that just takes the data structure
        public static Func<A, C> WithArg<A, B, C>(
            this Func<A, B, C> fn,
            B b
        ) =>
            (a) => fn(a, b);

        
        public static Func<A, D> WithArgs<A, B, C, D>(
            this Func<A, B, C, D> fn,
            B b,
            C c
        ) =>
            (a) => fn(a, b, c);


        public static Func<A, E> WithArgs<A, B, C, D, E>(
            this Func<A, B, C, D, E> fn,
            B b,
            C c,
            D d
        ) =>
            (a) => fn(a, b, c, d);
    }
}
