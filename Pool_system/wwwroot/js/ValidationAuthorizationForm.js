//Метод валидации формы
function validation(form)
{
  let result = true;
  let password;

  //Метод удаления ошибок
  function removeError(input)
  {
    const parent = input.parentNode; //Получаем родителя

    //Проверяем содержит ли родитель класс error (Добавляется при наличии ошибок в детях)
    if (parent.classList.contains('error'))
    {
      parent.querySelector('.error-label').remove(); //Удляем поле с ошибкой
      parent.classList.remove('error') //Удляем класс указывающий на наличие ошибок
    }
  }

  //Метод для вывода ошибок
  function createError(input, text)
  {
    const parent = input.parentNode; //Получаем id родителя
    const errorLabel = document.createElement('label'); //Создает поле для вывода ошибки

    parent.classList.add('error'); //Добавляет новый класс к объету, необходимо для подкраски бордера в красный цвет

    errorLabel.classList.add('error-label') //Добавляет к созданному полю класс
    errorLabel.textContent = text; //Добавляет в созданное поле текст ошибки

    parent.append(errorLabel);
  }




  //Проходимся циклом по всем input полям
  form.querySelectorAll('input').forEach(input => {

     removeError(input)//Запускаем метод по чистке ошибок (Чтобы ошибки не копились и исчезали при их устранении)

     //Проверка всех полей на их заполненность
     if (input.value == "") 
     {
       removeError(input)//Запускаем метод по чистке ошибок (Чтобы ошибки не копились и исчезали при их устранении)
       createError(input, "Поле обязательно для заполнения");
       result = false;
     }
  });

  return result
}


//Находим форму отправки данных по id и закрепляемся за событием submit (отправка формы) -> при нажатии на кнопку зарегистрироваться, будет срабатывать функция
document.getElementById("Authorization-Form").addEventListener('submit', function (event)
{
  
  //Передаем форму в метод валидации и проверяем что она успешно её прошла
  if (validation(this) == true)
  {
    return false;
  }
  else
  {
    //alert('В форме есть ошибки')
    event.preventDefault(); //Прерывает отправку формы
  }
})