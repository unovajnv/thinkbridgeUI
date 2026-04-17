document.addEventListener('DOMContentLoaded', function() {
    fetch('/api/invoice/1')
        .then(resp => resp.json())
        .then(data => {
            let html = `<h2>Customer: ${data.customerName}</h2>`;
            html += '<table><thead><tr><th>Item Name</th><th>Price</th></tr></thead><tbody>';
            data.items.forEach(item => {
                html += `<tr><td>${item.name}</td><td>$${item.price.toFixed(2)}</td></tr>`;
            });
            html += '</tbody></table>';
            
            const total = data.items.reduce((sum, item) => sum + item.price, 0);
            html += `<h3>Total: $${total.toFixed(2)}</h3>`;
            
            document.getElementById('invoice-container').innerHTML = html;
        })
        .catch(err => console.error("Failed to load invoice:", err));
});