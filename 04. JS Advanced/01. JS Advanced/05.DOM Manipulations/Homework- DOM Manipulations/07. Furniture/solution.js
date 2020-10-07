function solve() {

  //Generate Button
  document.querySelectorAll('button')[0].addEventListener('click', (e) => {
    let inputElement = e.target.previousElementSibling;
    let text = inputElement.value;

    JSON.parse(text).forEach(f => {
      let { name, img, price, decFactor } = f;

      let trElement = document.createElement('tr');

      //image
      let imgTdElement = document.createElement('td');
      let imgElement = document.createElement('img');
      imgElement.setAttribute('src', `${img}`);
      imgTdElement.appendChild(imgElement);
      trElement.appendChild(imgTdElement);

      //name
      let nameTdElement = document.createElement('td');
      let NamePElement = document.createElement('p');
      NamePElement.textContent = `${name}`;
      nameTdElement.appendChild(NamePElement);
      trElement.appendChild(nameTdElement);

      //price
      let priceTdElement = document.createElement('td');
      let pricePElement = document.createElement('p');
      pricePElement.textContent = `${price}`;
      priceTdElement.appendChild(pricePElement);
      trElement.appendChild(priceTdElement);

      //decFactor
      let factorTdElement = document.createElement('td');
      let factorPElement = document.createElement('p');
      factorPElement.textContent = `${decFactor}`;
      factorTdElement.appendChild(factorPElement);
      trElement.appendChild(factorTdElement);

      //checkBox
      let checkboxTdElement = document.createElement('td');
      let checkboxInputPElement = document.createElement('input');
      checkboxInputPElement.setAttribute('type', 'checkbox')
      checkboxTdElement.appendChild(checkboxInputPElement);
      trElement.appendChild(checkboxTdElement);


      document.querySelector('tbody').appendChild(trElement);

    });
  })

  let [name, price, factor] = [[], [], []];
  //Buy Button
  document.querySelectorAll('button')[1].addEventListener('click', (e) => {
    Array.from(document.querySelectorAll('tbody tr')).forEach(tr => {
      if (tr.children[4].children[0].checked) {
        name.push(tr.children[1].children[0].textContent)
        price.push(Number(tr.children[2].children[0].textContent))
        factor.push(Number(tr.children[3].children[0].textContent))
      }
    })


    let result = '';
    result += `Bought furniture: ${name.join(', ')}\n`;
    result+=`Total price: ${(price.reduce((a,b)=>{ return a+b},0).toFixed(2))}\n`
    result +=`Average decoration factor: ${factor.reduce((a,b)=>{ return a+b},0)/factor.length}`

    document.querySelectorAll('textarea')[1].textContent=result;

  })


}