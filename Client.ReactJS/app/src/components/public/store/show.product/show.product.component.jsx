import React from 'react'; 

class ShowProduct extends React.Component {
    render() {

        const model = {
            id: 1,
            title: "tiitles",
            description: "description",
            unitPrice: 5
        };

        return (
            <form>
                <input type="hidden" />
                <input type="hidden" />
                <input type="hidden" />
                <h3>{model.title}</h3>
                <h3>Price: {model.unitPrice} USD</h3>
                <p><b>Description: </b>{model.description}</p>
                <input type="submit" value="Add to Shopping Cart" />
            </form>
        )
    }
}

export default ShowProduct;

