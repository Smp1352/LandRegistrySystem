// wwwroot/js/parcel-form.js
function updateOwnershipProof() {
    var selected = [];
    var checkboxes = document.querySelectorAll('input[type="checkbox"][value]');

    checkboxes.forEach(function (checkbox) {
        if (checkbox.checked) {
            if (checkbox.id === 'proofOther') {
                var otherText = document.getElementById('otherProofText').value.trim();
                if (otherText) {
                    selected.push('سایر: ' + otherText);
                }
            } else {
                selected.push(checkbox.value);
            }
        }
    });

    document.getElementById('ownershipProofHidden').value = selected.join('، ');
}

function toggleOtherProof() {
    var otherCheckbox = document.getElementById('proofOther');
    var otherDiv = document.getElementById('otherProofDiv');
    var otherText = document.getElementById('otherProofText');

    if (otherCheckbox.checked) {
        otherDiv.style.display = 'block';
        otherText.focus();
    } else {
        otherDiv.style.display = 'none';
        otherText.value = '';
    }
    updateOwnershipProof();
}

// اضافه کردن رویداد به تمام چک‌باکس‌ها
document.addEventListener('DOMContentLoaded', function () {
    var checkboxes = document.querySelectorAll('input[type="checkbox"][value]');
    checkboxes.forEach(function (checkbox) {
        checkbox.addEventListener('change', updateOwnershipProof);
    });

    // رویداد برای فیلد "سایر"
    document.getElementById('otherProofText').addEventListener('input', updateOwnershipProof);
});

// تابع برای تنظیم مقدار اولیه در زمان ویرایش
function setOwnershipProofValues(selectedValues) {
    if (!selectedValues) return;

    var values = selectedValues.split('، ');
    var checkboxes = document.querySelectorAll('input[type="checkbox"][value]');

    checkboxes.forEach(function (checkbox) {
        if (checkbox.id === 'proofOther') {
            // بررسی مقدار "سایر"
            var otherMatch = values.find(v => v.startsWith('سایر: '));
            if (otherMatch) {
                checkbox.checked = true;
                document.getElementById('otherProofDiv').style.display = 'block';
                document.getElementById('otherProofText').value = otherMatch.replace('سایر: ', '');
            }
        } else {
            if (values.includes(checkbox.value)) {
                checkbox.checked = true;
            }
        }
    });

    updateOwnershipProof();
}