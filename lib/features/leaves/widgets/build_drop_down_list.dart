import 'package:athr_hr/core/styles/colors/my_colors.dart';
import 'package:athr_hr/core/styles/fonts/my_fonts.dart';
import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

void showLeaveDropdown({
  required BuildContext context,
  required TextEditingController controller,
  required List<String> options,
  required GlobalKey fieldKey,
}) {
  final RenderBox renderBox = fieldKey.currentContext!.findRenderObject() as RenderBox;
  final offset = renderBox.localToGlobal(Offset.zero);
  final fieldWidth = renderBox.size.width;

  OverlayEntry? overlayEntry;

  overlayEntry = OverlayEntry(
    builder: (context) => Positioned(
      left: offset.dx,
      top: offset.dy + renderBox.size.height + 5,
      width: fieldWidth, // match the field width
      child: Material(
        elevation: 4,
        borderRadius: BorderRadius.circular(8.sp),
        child: Container(
          decoration: BoxDecoration(
            color: Colors.white,
            borderRadius: BorderRadius.circular(8.sp),
          ),
          child: SingleChildScrollView(
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: options.map((option) {
                final bool isSelected = controller.text == option;
                return InkWell(
                  onTap: () {
                    controller.text = option;
                    overlayEntry?.remove();
                  },
                  child: Padding(
                    padding:  EdgeInsets.only(left:14.w,right: 14.w),
                    child: Container(
                      width: double.infinity,
                      padding: EdgeInsets.symmetric(horizontal: 16.w, vertical: 12.h),
                      decoration: BoxDecoration(
                        color: isSelected ? MyColors.activeColor : Colors.white,
                        borderRadius: BorderRadius.circular(8.sp),
                      ),
                      child: Text(
                        option,
                        style: MyFonts.semiBold600_18.copyWith(
                          color: isSelected ? Colors.white : MyColors.black,
                        ),
                      ),
                    ),
                  ),
                );
              }).toList(),
            ),
          ),
        ),
      ),
    ),
  );

  Overlay.of(context).insert(overlayEntry);
}
