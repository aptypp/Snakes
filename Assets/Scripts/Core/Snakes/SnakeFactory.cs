using System;
using System.Collections.Generic;
using Core.Food;
using Core.Snakes.Models;
using Core.Snakes.Views;
using UnityEngine;
using VContainer;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Core.Snakes
{
    public class SnakeFactory
    {
        private readonly FoodPool _foodPool;
        private readonly SnakesConfig _config;
        private readonly SnakesParent _snakesParent;

        [Inject]
        public SnakeFactory(
                FoodPool foodPool,
                SnakesConfig config,
                SnakesParent snakesParent)
        {
            _foodPool = foodPool;
            _config = config;
            _snakesParent = snakesParent;
        }

        public SnakeViewModel Create(
                Vector3 position)
        {
            var model = new SnakeModel(
                _foodPool,
                CreateTailView);

            var moveSpeed = Random.Range(
                _config.MoveSpeedMin,
                _config.MoveSpeedMax);

            var rotationSmoothDelta = Random.Range(
                _config.RotationSmoothDeltaMin,
                _config.RotationSmoothDeltaMax);

            model.Tails = new List<TailView>();
            model.MoveSpeed = moveSpeed;
            model.TargetPosition = position;
            model.MoveSmoothDelta = _config.MoveSmoothDelta;
            model.RotationSmoothDelta = rotationSmoothDelta;

            var view = Object.Instantiate(
                _config.SnakeViewPrefab,
                position,
                Quaternion.identity,
                _snakesParent.transform);

            view.AteFood += model.AteFood;

            for (var tailIndex = 0; tailIndex < _config.TailsCount; tailIndex++)
            {
                model.IncreaseTailsCount();
            }

            var viewModel = new SnakeViewModel(
                view,
                model);

            return viewModel;
        }

        private TailView CreateTailView(
                Vector3 position)
        {
            var view = Object.Instantiate(
                _config.TailViewPrefab,
                position,
                Quaternion.identity,
                _snakesParent.transform);

            return view;
        }
    }
}