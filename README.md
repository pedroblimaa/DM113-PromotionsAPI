# PromotionsAPI

PromotionsAPI is a .NET Web API that provides endpoints for managing promotions.

## Features

- **Create Promotion:** Create new promotions.
- **Get Promotion:** Retrieve details of a specific promotion.
- **Update Promotion:** Update an existing promotion.
- **Delete Promotion:** Delete a promotion.

## Getting Started

### Prerequisites

- [Docker](https://www.docker.com/get-started)


### Running the Application

1. Clone the repository:

    ```bash
    git clone https://github.com/pedroblimaa/PromotionsAPI.git
    ```

2. Navigate to the project directory:

    ```bash
    cd DM113-PromotionsAPI
    ```

3. Build the Docker image:

    ```bash
    docker-compose up
    ```

4. Use postman to make the requests **(Optional)**
    
    - Import in postman: `collection\DM113 - C#.postman_collection.json`
    - In the `Setup` request, in `Pre-Request Script` check if the URL/Port are correct
    - Run the setup to set up the variable
    - Use the collections to send the requests