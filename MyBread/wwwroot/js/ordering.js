let quantityNew = [];

let button = document.querySelector(".but");
button.addEventListener('click', function () {
    let success = 0;
    let size = 0;
    for (let i = 0; document.getElementById("bread" + i+"Name") !== null; i++) {
        let inputQuantity = document.getElementById("bread" + i).value * 1;
        let quantity = parseInt(document.getElementById("bread" + i + "Quantity").textContent);
        let prodId = parseInt(document.getElementById("prod" + i).textContent);
        if (inputQuantity <= quantity && inputQuantity >= 0) {
            success += 1;
            if (inputQuantity !== 0)
                quantityNew.push({prodId: prodId, quantity: inputQuantity});
        }
        size++;
    }
    if (success === size ) {
        document.getElementById("order").textContent = "Успешно";
        var xhr = new XMLHttpRequest();
        var url = "";
        // fetch('http://127.0.0.1:4040/api/tunnels')
        // fetch('http://localhost:8080/ordering')
        //     .then(response => response.json())
        //     .then(data => {
        //         const publicUrl = data.tunnels[0].public_url;
        //         const ipAddress = new URL(publicUrl).hostname;
        //         url = ipAddress
        //     })
        //     .catch(error => console.error('Ошибка получения IP-адреса ngrok:', error));
        let user = getCookie("cyxaruk");
        var data = JSON.stringify({"user": user, "quant_list": quantityNew});

        xhr.open("POST", "http://localhost:8080/ordering", true);
        xhr.setRequestHeader("Content-Type", "application/json");
        xhr.send(data);
        for (let i = 0; i < size; i++) {
            let inputQuantity = document.getElementById("bread" + i).value * 1;
            let quantity = parseInt(document.getElementById("bread" + i + "Quantity").textContent);
            document.getElementById("bread" + i + "Quantity").textContent = quantity - inputQuantity;
        }
    } else {
        document.getElementById("order").textContent = "Неверно введено количество";
        quantityNew = []
    }
});
function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}