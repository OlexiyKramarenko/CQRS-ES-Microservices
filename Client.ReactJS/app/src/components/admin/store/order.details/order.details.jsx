import React from 'react';

class OrderDetails extends React.Component {
    render() {
        return (
            <div>
                <div className="form-group">
                    <label className="control-label">Added Date:</label>
                    @Model.AddedDate
</div>

                <div className="form-group">
                    <label className="control-label">Added By:</label>
                    @Model.AddedBy
</div>

                <div className="form-group">
                    <label className="control-label">Customer Email:</label>
                    @Model.CustomerEmail
</div>

                <div className="form-group">
                    <label className="control-label">Customer Phone:</label>
                    @Model.CustomerPhone
</div>

                <div className="form-group">
                    <label className="control-label">Ordered Products:</label>
                    @foreach (var item in Model.Items)
	{
		// @item.Title
                                                }
</div>

                <div className="form-group">
                    <label className="control-label">Customer Phone:</label>
                    @Model.CustomerPhone
</div>

                <form  >
                    <div className="form-group">
                        <input type="hidden" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">Order Statuses:</label>
                        <select  ></select>
                    </div>
                    <input type="submit" value="Update order status" />
                </form>
            </div>
        )
    }
}

export default OrderDetails;