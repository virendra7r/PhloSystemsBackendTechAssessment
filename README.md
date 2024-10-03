# Phlo Systems Backend Tech Assessment

## Description
This project is an ASP.NET Core Web API that provides endpoints for managing and retrieving products. 
It allows users to filter products based on price, size, and highlights specific words in product descriptions.

## Features
- Retrieve a list of products with optional filtering by minimum and maximum price.
- Filter products by size.
- Highlight specific words in product descriptions.
- Exception handling with logging.

## Technologies Used
- ASP.NET Core
- C#
- Newtonsoft.Json for JSON handling

## Query Parameters:
minprice : Minimum price to filter products.
maxprice : Maximum price to filter products.
size : Size to filter products.
highlight : Comma-separated words to highlight in the product descriptions.
