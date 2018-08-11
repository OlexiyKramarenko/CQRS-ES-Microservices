import React from 'react';

class ShowProduct extends React.Component {
    render() {
        return (
            <div>
                <h3>Checkout</h3>
                <p>
                    account is required to proceed with the order submission. If you already have an account
                please login now, otherwise <a href="">create a new account</a> for feee.
            </p>
                <form >
                    <div className="text-danger"></div>
                    <div className="form-group">
                        <label className="control-label">FirstName</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">LastName</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">Email</label>
                        <input type="number" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">Street</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">PostalCode</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">City</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <label className="control-label">Phone</label>
                        <input type="number" className="form-control" />
                    </div>
                    <div className="form-group">
                        <select></select>
                    </div>
                    <div className="form-group">
                        <input type="submit" value="Send" className="btn btn-default" />
                    </div>
                </form>
            </div>
        )
    }
}

export default ShowProduct;

