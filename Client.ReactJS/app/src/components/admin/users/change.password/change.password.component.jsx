import React from 'react';

class ChangePassword extends React.Component {
    render() {
        return (
            <div>
                <h2>Change password for @Model.Email</h2>
                <form>
                    <div className="text-danger"></div>

                    <input type="hidden" />
                    <input type="hidden" />

                    <div className="form-group">
                        <label asp-for="NewPassword" className="control-label">Новый пароль</label>
                        <input type="text" className="form-control" />
                    </div>
                    <div className="form-group">
                        <input type="submit" value="Сохранить" className="btn btn-default" />
                    </div>
                </form>
            </div>
        )
    }
}

export default ChangePassword;