import 'package:flutter/material.dart';
import 'package:flutter_screenutil/flutter_screenutil.dart';

class CustomSwitch extends StatefulWidget {
  final bool value;
  final ValueChanged<bool> onChanged;
  final double width;
  final double height;

  const CustomSwitch({
    super.key,
    required this.value,
    required this.onChanged,
    this.width = 55,
    this.height = 32,
  });

  @override
  State<CustomSwitch> createState() => _CustomSwitchState();
}

class _CustomSwitchState extends State<CustomSwitch> {
  late bool isOn;

  @override
  void initState() {
    super.initState();
    isOn = widget.value;
  }

  @override
  Widget build(BuildContext context) {
    return GestureDetector(
      onTap: () {
        setState(() => isOn = !isOn);
        widget.onChanged(isOn);
      },
      child:
      GestureDetector(
        onTap: () {
          setState(() => isOn = !isOn);
          widget.onChanged(isOn);
        },
        child: Container(
          width: widget.width.w,
          height: widget.height.h,
          padding: EdgeInsets.all(1.w),
          decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(100.r),
            gradient: isOn
                ? const LinearGradient(
              colors: [
                Color(0xCC1BABB6),
                Color(0xCC005157),
              ],
            )
                : null,
            color: isOn ? null : const Color(0xFFCBCBCB),
          ),
          child: Container(
            decoration: BoxDecoration(
              borderRadius: BorderRadius.circular(100.r),
              color: Colors.white,
            ),
            padding: EdgeInsets.symmetric(horizontal: 2.w),
            child: AnimatedAlign(
              duration: const Duration(milliseconds: 200),
              curve: Curves.easeOut,
              alignment: isOn ? Alignment.centerRight : Alignment.centerLeft,
              child: Container(
                width: (widget.height - 10).w,
                height: (widget.height - 10).h,
                decoration: BoxDecoration(
                  shape: BoxShape.circle,
                  gradient: isOn
                      ? const LinearGradient(
                    colors: [
                      Color(0xCC1BABB6),
                      Color(0xCC005157),
                    ],
                  )
                      : null,
                  color: isOn ? null : const Color(0xFFCBCBCB),
                  boxShadow: [
                    BoxShadow(
                      color: Colors.black.withOpacity(0.18),
                      blurRadius: 2,
                      offset: const Offset(0, 2),
                    ),
                  ],
                ),
              ),
            ),
          ),
        ),
      )
    );
  }
}
