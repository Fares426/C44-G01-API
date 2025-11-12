using E_commerce.Shared.DataTransferObjects.Users;

namespace E_commerce.Shared.DataTransferObjects.UserOrder;

public record OrderRequest(AddressDTO Address, string BasketId, int DeliveryMehotdId);
