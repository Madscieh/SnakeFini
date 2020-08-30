﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class LevelGrid : MonoBehaviour
{
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;
    private int height;
    private int width;
    private Snake snake;

    public LevelGrid(int width, int height)
    {
        // Setup do LevelGrid no GameHandler
        this.width = width;
        this.height = height;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;

        SpawnFood();
    }

    private void SpawnFood()
    {
        // Evita que a comida surja sobre a cobra
        do
        {
            foodGridPosition = new Vector2Int(Random.Range(0, width), Random.Range(0, height));
        }
        while (snake.GetFullSnakeGridPosition().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food", typeof(SpriteRenderer));
        // Comida aleatória, criar no Game Assets
        foodGameObject.GetComponent<SpriteRenderer>().sprite = GameAssets.i.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y);
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if(snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            GameHandler.AddScore();
            CMDebug.TextPopupMouse("Snake Ate Food!");
            return true;
        }
        return false;
    }

     public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
    {
        if(gridPosition.x < 0)
        {
            gridPosition.x = width;
        }
        if(gridPosition.x > width)
        {
            gridPosition.x = 0;
        }
        if(gridPosition.y < 0)
        {
            gridPosition.y = height;
        }
        if(gridPosition.y > height)
        {
            gridPosition.y = 0;
        }
        return gridPosition;
    }
}
