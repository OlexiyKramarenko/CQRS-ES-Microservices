import React from 'react';

class CreateUser extends React.Component {
    render() {
        return (
            <form >
                <div className="text-danger"></div>
                <div className="form-group">
                    <label className="control-label">Email</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="form-group">
                    <label className="control-label">Пароль</label>
                    <input type="text" className="form-control" />
                </div>
                <div className="form-group">
                    <label className="control-label">Год рождения</label>
                    <input type="number" className="form-control" />
                </div>
                <div className="form-group">
                    <input type="submit" value="Добавить" className="btn btn-default" />
                </div>
            </form>
        )
    }
}

export default CreateUser;