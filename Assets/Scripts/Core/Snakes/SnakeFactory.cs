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

        public SnakeViewModel Create()
        {
            var model = new SnakeModel(_foodPool);

            var moveSpeed = Random.Range(
                _config.MoveSpeedMin,
                _config.MoveSpeedMax);

            var rotationSmoothDelta = Random.Range(
                _config.RotationSmoothDeltaMin,
                _config.RotationSmoothDeltaMax);

            model.Tails = new List<TailView>();
            model.MoveSpeed = moveSpeed;
            model.MoveSmoothDelta = _config.MoveSmoothDelta;
            model.RotationSmoothDelta = rotationSmoothDelta;

            var snakeView = Object.Instantiate(
                _config.SnakeViewPrefab,
                Vector3.zero,
                Quaternion.identity,
                _snakesParent.transform);

            snakeView.AteFood += model.AteFood;

            var viewModel = new SnakeViewModel(
                snakeView,
                model);

            return viewModel;
        }

        private TailView CreateTailView(Vector3 position) //Todo: implement logic for creating a tail parts
        {
            throw new NotImplementedException();
        }
    }
}