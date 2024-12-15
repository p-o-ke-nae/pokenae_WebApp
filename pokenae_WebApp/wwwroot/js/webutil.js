function getFormData(){
    const form = document.querySelector('form'); // フォームを取得
    const jsonObject = {};

    if (form) {
        // フォームデータを収集
        const formData = new FormData(form);

        formData.forEach((value, key) => {
            // キーからプレフィックスを取り除く
            const propertyName = key.includes('.') ? key.split('.').pop() : key;
            const inputElement = form.querySelector(`[name="${key}"]`);
            // チェックボックスの値を適切に変換
            if (inputElement && inputElement.type === 'checkbox') {
                jsonObject[propertyName] = inputElement.checked;
            } else {
                jsonObject[propertyName] = value;
            }
        });
    }

    return jsonObject;
}