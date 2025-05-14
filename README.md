# PruebaTecnica API

API RESTful desarrollada en ASP.NET Core (.NET 8) para la gestión de productos y pedidos.  
Incluye endpoints para crear, consultar, actualizar y eliminar productos, así como para crear y consultar pedidos con sus detalles.

---

## Endpoints principales

### Productos (`/api/product`)

- **GET `/api/product/{id}`**  
  Obtiene un producto por su ID.

- **POST `/api/product`**  
  Crea un nuevo producto.  
  **Body ejemplo:**

- **PUT `/api/product/{id}`**  
  Actualiza un producto existente.  
  **Body ejemplo:*

- **DELETE `/api/product/{id}`**  
  Elimina un producto por su ID.

### Ordenes (`/api/order`)

- **GET `/api/order/{id}`**  
  Obtiene un pedido por su ID.

- **POST `/api/order`**  
  Crea un nuevo pedido con sus detalles.  
  **Body ejemplo:**

  ## Requisitos

- .NET 8
- SQL Server (ver `appsettings.json` para la cadena de conexión)

## Notas

- El stock de productos se descuenta automáticamente al crear una orden.
- Los detalles del pedido (`orderItems`) se envían junto con el pedido en el mismo JSON.
- No es necesario enviar el `orderId` en los `orderItems` al crear una orden.


  
