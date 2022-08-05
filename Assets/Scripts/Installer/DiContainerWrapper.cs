using System;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class DiContainerWrapper
    {
        private readonly DiContainer _container;

        public DiContainerWrapper(DiContainer container)
        {
            _container = container;
        }

        public void BindInterfacesToSingle<T>()
        {
            _container
                .BindInterfacesTo<T>()
                .AsSingle();
        }

        public void BindInterfacesAndSelfToSingle<T>()
        {
            _container
                .BindInterfacesAndSelfTo<T>()
                .AsSingle();
        }

        public void BindSingle<TBind>()
        {
            CheckDisposable(typeof(TBind));
            _container
                .Bind<TBind>()
                .AsSingle();
        }

        public void BindSingle<TBind>(params Type[] types)
        {
            CheckDisposable(typeof(TBind));
            _container
                .Bind(types)
                .To<TBind>()
                .AsSingle();
        }

        public void BindSingleDisposable<TBind>() where TBind : IDisposable
        {
            _container
                .Bind(typeof(TBind), typeof(IDisposable))
                .To<TBind>()
                .AsSingle();
        }

        public ConcreteIdArgConditionCopyNonLazyBinder BindSingleDisposable<TBind, TTo>() where TTo : TBind, IDisposable
        {
            return _container
                .Bind(typeof(TBind), typeof(IDisposable))
                .To<TTo>()
                .AsSingle();
        }

        public void BindSingleToInstance<TBind>(TBind instance)
        {
            CheckDisposable(typeof(TBind));
            _container
                .Bind<TBind>()
                .FromInstance(instance)
                .AsSingle();
        }

        public ConcreteIdArgConditionCopyNonLazyBinder BindDisposableSingle<T>() where T : IDisposable
        {
            return _container
                .Bind(typeof(T), typeof(IDisposable))
                .To<T>()
                .AsSingle();
        }

        public ConcreteIdArgConditionCopyNonLazyBinder BindDisposableSingle<T1, T2>() where T2 : T1, IDisposable
        {
            return _container
                .Bind(typeof(T1), typeof(IDisposable))
                .To<T2>()
                .AsSingle();
        }

        public void BindSingle<TIn, TOut>() where TOut : TIn where TIn : class
        {
            CheckDisposable(typeof(TOut));
            _container.Bind<TIn>().To<TOut>().AsSingle();
        }

        public void BindFromInstance<TIn>(TIn instance)
        {
            _container
                .Bind<TIn>()
                .FromInstance(instance);
        }

        public void BindSingleFromInstance<TIn>(TIn instance)
        {
            CheckDisposable(typeof(TIn));
            _container
                .Bind<TIn>()
                .FromInstance(instance)
                .AsSingle();
        }

        public void BindSingleDisposableToInstance<TBind>(TBind instance)
        {
            _container
                .Bind(typeof(TBind), typeof(IDisposable))
                .FromInstance(instance)
                .AsSingle();
        }

        public void BindSingleInterfacesAndSelfFromInstance<TBind>(TBind instance)
        {
            _container
                .BindInterfacesAndSelfTo<TBind>()
                .FromInstance(instance)
                .AsSingle();
        }

        public void BindNonLazySingle<TObj>()
        {
            CheckDisposable(typeof(TObj));
            _container
                .Bind<TObj>()
                .AsSingle()
                .NonLazy();
        }

        public void BindNonLazySingle<TObj>(params Type[] types)
        {
            CheckDisposable(typeof(TObj));
            _container
                .Bind(types)
                .To<TObj>()
                .AsSingle()
                .NonLazy();
        }

        public void BindNonLazySingleInstance<TObj>(TObj instance)
        {
            CheckDisposable(typeof(TObj));
            _container
                .BindInstance(instance)
                .AsSingle()
                .NonLazy();
        }

        public FromBinderNonGeneric BindInterfacesAndSelfTo<T>()
        {
            return _container.BindInterfacesAndSelfTo<T>();
        }

        public T Instantiate<T>()
        {
            return _container.Instantiate<T>();
        }

        public T Resolve<T>()
        {
            return _container.Resolve<T>();
        }

        private static void CheckDisposable(Type type)
        {
#if UNITY_EDITOR // && !ENABLE_PROFILER
            Type[] types = type.FindInterfaces((t, c) => t == typeof(IDisposable), null);
            if (types.Length > 0)
            {
                Debug.LogWarning($"Bind IDisposable inheritor without it. {type}");
            }
#endif
        }
    }
}
